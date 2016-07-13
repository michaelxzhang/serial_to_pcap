
;This script will read the SSNET communication log file and convert it to pcapng file for Wireshark    
	
FileSelectFile, SourceFile, 3,, Pick a Communication log file
if SourceFile =
    return  ; This will exit in this case.

SplitPath, SourceFile,, SourceFilePath,, SourceFileNoExt
tempF = %SourceFilePath%\%SourceFileNoExt%_n.txt
DestFile = %SourceFilePath%\%SourceFileNoExt%.pcapng

IfExist, %tempF%
{
    ;MsgBox, 4,, Overwrite the existing links file? `n`nFILE: %tempF%
    ;IfMsgBox, Yes
    FileDelete, %tempF%
}

;read the list from the protolist.txt under the current folder
;each item should be "protocol name @portnum"
;no space between @ and portnum
IfExist, protolist.txt
{
	loop, read, protolist.txt
	{
		liststr = %liststr%%A_LoopReadLine%|
	}
}
else
{
	MsgBox, File protolist.txt not exists!`nDefault protocol list will be used!
	liststr = DNP 3.0 @20000|IEC 104 @2404|IEC 61850  @102|Modbus TCP @502
}

;Msgbox, %liststr%

Gui, Add, ComboBox, vProtoList x32 y40 w180 h120 , %liststr%
Gui, Add, Text, x32 y10 w170 h30 , Please select or enter the default protocol port:
Gui, Add, Button, x222 y30 w100 h30 , Convert

; Generated using SmartGUI Creator 4.0
Gui, Show, x145 y94 h95 w351, Comm log converter


Return


GuiClose:
ExitApp

ButtonConvert:

	;get the current selected value
	GuiControlGet, selectedproto, ,ProtoList
	StringLen, strlen, selectedproto
	StringGetPos, startpos, selectedproto, @
	
	;extract the port number info from the current selected item
	StringRight, protonum, selectedproto, strlen - startpos - 1
	;Msgbox, %strlen% - %startpos% = %protonum%
	
	;start the convert job
	Loop, read, %SourceFile%, %tempF%
	{
		
		;Timestamp line stat with '['
		char1 := SubStr(A_LoopReadLine,1,1)
		;IfInString, A_LoopReadLine, [
		If (char1 = "[")
		{
			;MsgBox, %A_LoopReadLine%
			
			;If found Rx, remove '[' and put 'I ' at beginning
			IfInString, A_LoopReadLine, Rx
			{
				StringReplace, nStr, A_LoopReadLine, [, I%A_Space%
			}
			;If found Tx, remove '[' and put 'O ' at beginning
			IfInString, A_LoopReadLine, Tx
			{
				StringReplace, nStr, A_LoopReadLine, [, O%A_Space%
			}
			FileAppend, %nStr%`n
			datapacketlinecnt := 0
		} ;IfInString [
		;If not timestamp line, it should be data line
		else
		{
			;MsgBox, %A_LoopReadLine%
			char1 = "N"
			char2 = "N"
			char3 = "N"
			char1 := SubStr(A_LoopReadLine,1,1)
			char2 := SubStr(A_LoopReadLine,2,1)
			char3 := SubStr(A_LoopReadLine,3,1)
			;MsgBox, ##%char1%##%char2%##%char3%##
			
			;data line first two are hex, third is space
			;if char1_2 is xdigit
			if (IsHex(char1)=1 and IsHex(char2) = 1)
			{
				if char3 is space
				{
					;MsgBox, dataline
					;SetFormat, IntegerFast, HEX
					
					;add offset at the begining of dataline
					fmtstr := Format("{1:04X}", datapacketlinecnt)
					FileAppend, %fmtstr% %A_LoopReadLine%`n
					datapacketlinecnt := datapacketlinecnt + 15
				}
				else
				{
					;MsgBox, not dataline
					FileAppend, #%A_LoopReadLine%`n
				}
			}
			;others, just comment it with #
			else
			{
				;MsgBox, others
				FileAppend, #%A_LoopReadLine%`n
			}
			
		}

	}  ; Loop Read

	RunWait, "C:\Program Files\Wireshark\text2pcap.exe" -D -T 1111`,%protonum% -t `%H:`%M:`%S. %tempF% %DestFile%
	
	ExitApp
	;return
	
IsHex(number)
{
	if number in 0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,A,B,C,D,E,F
		return 1
	else 
		return 0
}

Feature: Total Commander
@mytag
Scenario: Operations with folders and files
	Given Total Commander was opened and the InfoWindow closed
		And Two folders were opened
	When The user drags the file from the first folder to the second
		And The user confirm copying
	Then The file is in the second folder
	When The user cuts the file in the second folder
		And The user pastes the file in the first folder
		And The user chooses the <replace> option
	Then The file is in the first folder and it isn't in the second
	When The user opens separate tree
		And The user does double click on <Switch through tree panel options> button
		And The user selects the first panel and click <Search> button
		And The user enters file name in field <Search for>
		And The user sets the <RegEx> checkbox and clicks <Start Search> button
	Then Only one file found
	When The user clicks on the cross
	Then The Search window is close
	When The user chooses from menu Edit Comment
	Then A window appeared warning that no files were selected
	When The user clicks OK and chooses from menu Quit
	Then Total Сommander is close
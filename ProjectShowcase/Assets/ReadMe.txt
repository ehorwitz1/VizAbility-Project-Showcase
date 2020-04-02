JsonHandler (HandlerJson Script):
	Deals with the reading and handling of the Json file
	Gets the filepath and parses the data into a list of JsonClass objects
		It has all the columns of the Json file we read in
	After the script completes theres a list of objects that match the features in the table thats read in. 

GridWithElementsOrOptions (ButtonHandler Script):
	There was definitely some experimentation that went on with the scroll rect 
	The ButtonHandler script deals with creating the buttons and setting their parents
		It takes the info of each row in the Jsonfile from the JsonHandler and applies the information to each button
			Each button holds the information from the row in the table

TextHolder (TextHandler Script)
	The ButtonHandler calls the setAllText() method when the listener is clicked
	It gets the info from the button and sets the text elements that are childed to the object

Flow of scripts:
HandlerJson gets all the data from the Json file that was read in from the Google to Json asset and puts it into a list of Json classes
ButtonHandler gets the info from the HandlerJson and makes a button for each of the elements in the list of Json classes
	The buttons have a listener that interact with the textHandler
TextHandler gets the info from the active button and sets the text on the canvas equal to whats in the button
	
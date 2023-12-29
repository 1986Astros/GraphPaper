# GraphPaper

There are two versions of the GraphPaper application, one in C# and the other in VB.Net. The two versions are functionally identical, and the code is identical, line-for-line, as much as possible.

The application will generate graph paper in the familiar squares, as well as circlea, triagles, diamonds and hexagons. Any dimension can be sspecified for the size of shapes and the thickness of the lines in inches or millimeters.

The applications make use of:
* GraphicsPath for drawing hexagons of a specified size
* trigonometric functions to draw some of the shapes
* Matrix for rotating and moving shapes
* LINQ
* lambda expressions
* the Color struct and KnownColors
* owner-drawn ComboBox
* Events
* XML with Datasets for storing user preferences
* printing
* TableLayoutPanels, embedded to control layout
* Attributes on Properties
* Enum.IsDefined and various versions of TryParse including Enum.TryParse
* checkmarks on a menu

There are opportunities to learn or practive skills by enhancing the application.
* Change the color of the background
* Interlocking circles or other shapes
* Writing the paper as an image file (JPG, PNG, etc) instead of sending it to the printer
* Implementing the GraphPaperControl in a Class Library (VB.Net version only)

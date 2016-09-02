# Style Rules
## File Header

All files shall contain the standard file header at the top of the file.  The file header must:

* Match the style of the ```Program.cs``` file Header.
* Contain the name of the class/interface, generated with the BigFont tool using Graffiti font and size large for uppercase characters and medium for lower.
* Contain a brief overview of the purpose of the class.  This must match the first paragraph of the summary tag for the xml documentation for the class.
* Contain the GNU AGPL v3 license introduction.

## Namespaces

The root namespace of the application must remain ```Symbiote.Core```.  Additional namespaces within the root application namespace must be accompanied by a project
folder of the same name.  All namespaces are to be in Pascal case (or start case).  Conversely, all project folders must contain code with a namespace corresponding 
to the folder name.  The only exception is the ```Common```
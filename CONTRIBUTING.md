# Style Rules
## Namespaces

The root namespace of the application must remain ```Symbiote.Core```.  Additional namespaces within the root application namespace must be accompanied by a project
folder of the same name.  All namespaces are to be in Pascal Case.  Conversely, all project folders must contain code with a namespace corresponding 
to the folder name.  The only exception is the ```Common``` folder in which miscellanous files within the ```Symbiote.Core``` namespace are stored.

Plugin namespaces must begin with ```Symbiote.Plugin```.  Currently the third tuple of the namespace must match the plugin type, e.g. ```Symbiote.Plugin.Connector```, however this is subject to change.  The final tuple must match the plugin name, however, regardless of the presense of the plugin type.

## StyleCop

StyleCop must be used to ensure compliance with generally accepted code formatting and organizational standards.  The ```Settings.StyleCop``` file from the ```Symbiote.Core```
project should be copied to projects to ensure consistency.  The default StyleCop rules are used with the following exceptions:

* Documentation Rules\File Headers category (conflicts with my stylistic approach)
* SA1200: UsingDirectivesMustBePlacedWithinNamespace (conflicts with the management (adds, sorting) functionality of Visual Studio)
* SA1101: PrefixLocalCallsWithThis (ridiculous rule in most cases, feel free to use the prefix to disambiguate where appropriate)
* SA1126: PrefixCallsCorrectly (deprecated and impossible to satisfy in some cases)

## File Header

All files must contain the standard file header at the top of the file.  The file header must:

* Match the general style of the ```Program.cs``` file header.
* Contain the name of the class/interface, generated with the BigFont tool using Graffiti font and size large for uppercase characters and medium for lower.
* Contain a brief summary of the class or interface.  This must match the first paragraph of the summary tag for the xml documentation for the class or interface.
* Contain the GNU AGPL v3 license introduction.

## XML Documentation

XML documentation must be provided for all code elements.  

Text within ```<summary>``` and ```<para>``` tags must be indented.  

Where possible, references to types/classes, members, methods, or other code elements must be wrapped with a ```<see>``` tag in order to ensure the navigability of the generated documentation.  References that would
be redundant, such as those pertaining to the current class, or those within ```<return>``` and/or ```<param>``` tags must be omitted.

Exceptions explicitly thrown within methods must list and describe each thrown exception with ```<exception>``` tags.  Descriptions must start with "Thrown when...".

Non-trivial code and classes must be documented verbosely and should include rationale regarding design decisions or any counterintuitive aspects of the code.

Any non-trivial method which has been specifically designed or otherwise known to be thread safe must use the ```<threadsafety>``` tag.  Any method lacking this tag is assumed to be thread un-safe.

## General Code Standards

The contents of classes and interfaces must be organized according to StyleCop rules, which are described [here](http://stackoverflow.com/questions/150479/order-of-items-in-classes-fields-properties-constructors-methods/310967#310967).

Each section must be enclosed in a code region corresponding to the section contents, in Pascal Case, with spaces between words.  E.g. "Public Static Methods".

### Concrete Rules

The following rules must be followed:

* No public fields (use properties).
* No underscore prefix for private fields.
* No interfaces within classes (use a separate file).
* No structs (create a class).
* No using the "var" keyword (explicitly define all variable types).

### Firm Guidelines

The following rules should be followed, with few exceptions:

* Minimize private fields (utility/generic stuff is ok, for everything else use private properties).
* Avoid enumerations within classes (preference is a separate file).
* Avoid nested classes (preference is a separate file).

## Composition

Classes must explicitly list all interfaces implemented, even if those interfaces are implemented by inherited classes.  Interfaces must be listed in order of "lowest" to "highest" with respect
to the postion in the inheritance heirarchy of the implementing class.  Interfaces implemented at the same level may appear in any order.

The ```Public Properties``` and ```Public Instance Methods``` code regions must contain code regions for each interface implementation, in the order in which they are specified in the class signature.
These regions must be named ```I<interface> Properties``` and ```I<interface> Implementation```, respectively.  If an interface is implemented in an inherited class, these regions must contain a comment matching
one of the following examples, depending on whether it is a property or method:

```//// See the <implementing> class for the I<interface> <properties|implementation> for this class.```

## Exceptions

Only exceptions which should stop the application may be thrown explicitly.  Thrown exceptions should attempt to use a framework defined exception type at the site of the exception, if one is applicable.  If not, custom
exceptions must be created and stored in a single file named ```<namespace|subject>Exceptions.cs``` where the containing namespace or subject of the exceptions is contained within the name.  For example, exceptions relating to the application Model
must store all model related exceptions in ```ModelExceptions.cs```.

All exception classes must be contained within the file.  Suppress StyleCop rule SA1402 to eliminate warnings.  The first exception class must extend ```Exception``` and must match the filename; e.g. the first exception class
within ```ModelExceptions.cs``` would be ```ModelException```.  All further exceptions must extend this class.

Where possible, exceptions should be re-thrown as inner exceptions at each level back to Main().  For example, if an exception is generated while loading the configuration file during startup, the exception heirarchy might look like the following:

* ApplicationStartException
..* ConfigurationManagerStartException
....* ConfigurationLoadException
......* JsonSerializationException

Each level of the exception hierarchy should describe the general task that was being carried out when the exception was thrown; e.g. exceptions thrown while loading the configuration file should, at the level above the exception site,
re-throw the lower exception as a ```ConfigurationLoadException``` with the initial exception as an inner exception.

This strategy should aid in debugging and support as the application scales.

## Operation Results

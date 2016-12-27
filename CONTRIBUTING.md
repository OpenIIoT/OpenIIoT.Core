# Project Rules and Guidelines

## Project Organization

All classes, interfaces, enumerations which need to be accessible to plugins, in addition to exceptions and other trivial classes, must reside in the ```Symbiote.SDK``` project.  Organization of the ```Symbiote.SDK``` project must
mirror that of the ```Symbiote.Core``` project.

## Testing

All projects containing source code must have an accompanying Unit Test project named ```<project>.Tests``` where the project under test preceeds the final period in the project name.  For example,
the project ```Symbiote.SDK``` must have a Unit Test project named ```Symbiote.SDK.Tests``` within the same solution.

Test project organization must mirror the project under test, and test classes must mirror the names of the classes being tested.  The file header for the Unit Test class must match that of the class under test followed by
the word "Test" on a new line under the name of the class.  The verbiage of the class description must be ```Unit tests for the <class> class.```, where ```<class>``` is the name of the class under test.

Unit tests classes must share the name of the class under test, and each class must include the "Collection" attribute, assigning the name of the unit test class as the collection name.  The summary documentation for unit test classes must follow the following pattern, where ```<class name>``` is substituted for the name of the class under test:

```Unit tests for the <see cref="<class name>"> class.```

The [xUnit](https://xunit.github.io/) framework must be used for all unit tests.  Runners for Visual Studio and the Console should also be installed.  

[OpenCover](https://github.com/OpenCover/opencover) is required to support CI via Appveyor as well as the optional but recommended [OpenCover.UI](https://marketplace.visualstudio.com/items?itemName=jamdagni86.OpenCoverUI)
coverage extension for Visual Studio.

The code coverage target for all classes is _95%_ or above, preferably 100%.  Classes failing to reach 95% coverage must be refactored such that the target may be reached.

The [Moq](https://github.com/moq/moq) mocking framework must be used to mock any non-trivial objects required for unit testing, where practical.  If a test must use a concrete mockup, the code for the mockup must be included
within the file in which it is used.  The rationale explaining why a mocking framework must be included in the remarks section of the XML documentation for the class, and any unit test dependent upon the mockup must state the depencency
in the remarks section of the XML documentation for that unit test.

## Coding Standards and Styling

### Namespaces

The root namespace of the application must remain ```Symbiote.Core```.  Additional namespaces within the root application namespace must be accompanied by a project
folder of the same name.  All namespaces are to be in Pascal Case.  Conversely, all project folders must contain code with a namespace corresponding 
to the folder name.  The only exception is the ```Common``` folder in which miscellanous files within the ```Symbiote.Core``` namespace are stored.

Plugin namespaces must begin with ```Symbiote.Plugin```.  Currently the third tuple of the namespace must match the plugin type, e.g. ```Symbiote.Plugin.Connector```, however this is subject to change.  The final tuple must match the plugin name, however, regardless of the presense of the plugin type.

### StyleCop

[StyleCop](https://github.com/StyleCop) must be used to ensure compliance with generally accepted code formatting and organizational standards.  The [Settings.StyleCop](https://github.com/Symbiote/Symbiote.Settings/blob/master/Settings.StyleCop) 
file from the [Symbiote.Settings](https://github.com/Symbiote/Symbiote.Settings)
repository should be copied to projects to ensure consistency.  The default StyleCop rules are used with the following exceptions:

* Documentation Rules\File Headers category (conflicts with my stylistic approach)
* SA1200: UsingDirectivesMustBePlacedWithinNamespace (conflicts with the management (adds, sorting) functionality of Visual Studio)
* SA1101: PrefixLocalCallsWithThis (ridiculous rule in most cases, feel free to use the prefix to disambiguate where appropriate)
* SA1126: PrefixCallsCorrectly (deprecated and impossible to satisfy in some cases)

### CodeMaid

[CodeMaid](http://www.codemaid.net/) must be used to organize and format source files.  The [CodeMaid.config](https://github.com/Symbiote/Symbiote.Settings/blob/master/CodeMaid.config) file from the [Symbiote.Settings](https://github.com/Symbiote/Symbiote.Settings)
repository should be imported into the CodeMaid Options dialog to ensure consistency.  The default CodeMaid options are used with the following exceptions:

* Insert New Regions: True
* Regions Include Access Level : True
* Keep XML Tags Together: True
* XML Value Indent: 4
* Format Comments During Cleanup: True
* Auto Cleanup On File Save: True (this is optional)
* Sort Using Statements During Cleanup: False (conflicts with StyleCop; sorts alphabetically and moves System.* from the top)
* Comment Wrap Columns: 130

### File Header

All files must contain the standard file header at the top of the file.  The file header must:

* Match the general style of the ```Program.cs``` file header.
* Contain the name of the class/interface, generated with the BigFont tool using Graffiti font and size large for uppercase characters and medium for lower.
* Contain a brief summary of the class or interface.  This must match the first paragraph of the summary tag for the xml documentation for the class or interface.
* Contain the GNU AGPL v3 license introduction.

### XML Documentation

XML documentation must be provided for all code elements.  

Text within ```<summary>``` and ```<para>``` tags must be indented.  

Where possible, references to types/classes, members, methods, or other code elements must be wrapped with a ```<see>``` tag in order to ensure the navigability of the generated documentation.  References that would
be redundant, such as those pertaining to the current class, or those within ```<return>``` and/or ```<param>``` tags must be omitted.

Exceptions explicitly thrown within methods must list and describe each thrown exception with ```<exception>``` tags.  Descriptions must start with "Thrown when...".

Non-trivial code and classes must be documented verbosely and should include rationale regarding design decisions or any counterintuitive aspects of the code.

Any non-trivial method which has been specifically designed or otherwise known to be thread safe must use the ```<threadsafety>``` tag.  Any method lacking this tag is assumed to be thread un-safe.

Trivial or "utility" code must implement XML documentation in order to satisfy StyleCop, however the inclusion of rationale and the level of verbosity is at the author's discretion.

### General Code Standards

The contents of classes and interfaces must be organized according to StyleCop rules, which are described [here](http://stackoverflow.com/questions/150479/order-of-items-in-classes-fields-properties-constructors-methods/310967#310967).

Each section must be enclosed in a code region corresponding to the section contents, in Pascal Case, with spaces between words.  E.g. "Public Static Methods".  The Event Handlers region must be used to identify event handlers.  All event handlers must be implemented as private instance methods.

Interface implementations are subject to additional rules; see the Composition section below.

#### Concrete Rules

The following rules must be followed:

* No public fields (use properties).
* No underscore prefix for private fields.
* No interfaces within classes (use a separate file).
* No structs (create a class).
* No using the "var" keyword (explicitly define all variable types).

#### Firm Guidelines

The following rules should be followed, with few exceptions:

* Minimize private fields (utility/generic stuff is ok, for everything else use private properties).
* Avoid enumerations within classes (preference is a separate file).
* Avoid nested classes (preference is a separate file).

### Logging

[NLog](http://nlog-project.org/) is used for all logging within the application.  The [NLog.xLogger](https://github.com/jpdillingham/NLog.xLogger) extension is mandatory for the ```Symbiote.Core``` and ```Symbiote.SDK``` projects and preferred
but not required for all other projects.

Non-trivial methods within the ```Symbiote.Core``` and ```Symbiote.SDK``` projects must use the ```EnterMethod()``` and ```ExitMethod()``` methods from the ```xLogger``` extension.  Exceptions may be made for methods relating to the manipulation
and reading and writing of the application model and model items.

Log messages and and the logging level at which they are logged are discretionary.  Developers are encouraged to review the messages at the ```Trace```, ```Debug``` and ```Info``` logging levels for overall style and "fit" with
the whole of the application.  In general, messages logged with the ```Info``` level should be targeted to a semi-technical person.

### Exceptions

Only exceptions which should stop the application may be thrown explicitly.  Thrown exceptions should attempt to use a framework defined exception type at the site of the exception, if one is applicable.  If not, custom
exceptions must be created and stored in a single file named ```<namespace|subject>Exceptions.cs``` where the containing namespace or subject of the exceptions is contained within the name.  For example, exceptions relating to the application Model
must store all model related exceptions in ```ModelExceptions.cs```.  Exception classes must be stored in the ```Symbiote.SDK``` project.

All exception classes must be contained within the file.  Suppress StyleCop rule SA1402 to eliminate warnings.  The first exception class must extend ```Exception``` and must match the filename; e.g. the first exception class
within ```ModelExceptions.cs``` would be ```ModelException```.  All further exceptions must extend this class.

Where possible, exceptions should be re-thrown as inner exceptions at each level back to Main().  For example, if an exception is generated while loading the configuration file during startup, the exception heirarchy might look like the following:

```
ApplicationStartException
	ConfigurationManagerStartException
		ConfigurationLoadException
			JsonSerializationException
```

Each level of the exception hierarchy should describe the general task that was being carried out when the exception was thrown; e.g. exceptions thrown while loading the configuration file should, at the level above the exception site,
re-throw the lower exception as a ```ConfigurationLoadException``` with the initial exception as an inner exception.

This strategy should aid in debugging and support as the application scales.

### Operation Results

Methods which need to return status information or errors, other than fatal exceptions, must have a return type of [Operation Result](https://github.com/jpdillingham/OperationResult).  Methods returning values must use the generic variant ```Result<T>```.

The usage of this class allows the application to gracefully handle recoverable errors without the expense of exceptions, and eliminates the need for sentinal values in return types.







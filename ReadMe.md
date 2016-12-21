#NemCore

NemCore is a library of various things I've found to be useful, but not things that I can easily classify together into a meaningful unit.

Right now there is only one thing available; the LogFileListener class.

###LogFileListener

LogFileListener is an implementation of a TraceListern designed for writing out a log file.

There isn't much to it.  If you specify a log file name, it will try to use that.  If you don't, it will base the name on the running process.
The only reason it wouldn't use the name you specify is if the file is already in use.  If that's the case it will simply append a number to the filename so you would get things like "log_2.log."

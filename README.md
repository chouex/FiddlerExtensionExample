# FiddlerExtensionExample
FiddlerExtensionExample for Instector and tamper traffic


#Response Instector
by implementing body{set}

This Example just beautify the json body. 


#Request Instector
TODO

#Traffic Tamper
TagCookies.cs from http://docs.telerik.com/fiddler/Extend-Fiddler/CookieExtension

by implementing AutoTamperResponseBefore()

This Example just replace any text "xt" to "c1" in every request body



note:
I used pre/post-build script to copy dll and restart fiddler in this project.

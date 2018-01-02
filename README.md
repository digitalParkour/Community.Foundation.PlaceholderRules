Sitecore - Community.Foundation.PlaceholderRules
==============

Summary
--------------

This extensions allows you to manage allowed placeholder settings with rules (similar to insert option rules) instead of configuring placeholder setting items directly. This is helpful when using component driven design or using third party placeholders which can be overwritten with future upgrades (SXA).

Usage
--------------
Manage rules under /sitecore/system/Settings/Rules/Placeholder Renderings/Rules

[View screenshots in the wiki](https://github.com/digitalParkour/Community.Foundation.PlaceholderRules/wiki).

  
Setup
--------------
Either:
* Install Sitecore package:  
	\\releases\\Community.Foundation.PlaceholderRules-\*.zip  
			
Or:
1. Include this project in your Helix style solution
2. Update NuGet references to match target sitecore version
3. Install sitecore package for data or enable Foundation.PlaceholderRules.Serialization.config and sync unicorn

FYI
--------------
This was built and tested with Sitecore 8.2 update 5 and update 6. Also works well with SXA.

This package adds the following files:

    /bin/Community.Foundation.PlaceholderRules.dll
    /bin/Community.Foundation.PlaceholderRules.pdb

    /App_Config/Include/Foundation/Foundation.PlaceholderRules.config  
    /App_Config/Include/Foundation/Foundation.PlaceholderRules.Serialization.config.example

This package adds data items to the following locations:

    /sitecore/templates/Foundation/PlaceholderRules
    /sitecore/system/Settings/Rules/placeholder-renderings
    /sitecore/system/Settings/Rules/Definitions/Tags/Placeholder Renderings
    /sitecore/system/Settings/Rules/Definitions/Elements/placeholder-renderings

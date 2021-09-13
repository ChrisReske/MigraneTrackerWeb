# MgMateWeb

A web application to log migrane attacks.

## Motivation

Keeping track of migrane attacks and their circumstances. Most therapies still rely on filling out sheets of paper to be read and analysed by the specialist doctor. However, co-occurrences or root causes might not be spotted when analysing data from paper sheets. Additionally, I wanted to include weather data as a feature, because I know that the weather does affect my health. Adding weather data on paper would be very tedious. Moreover, current phone apps do not take into account weather data, either. This brings me to the next point: Current apps lack some features I deem valuable. Moreover, some apps do not even feature data exports to human readable formats.

## Uses Cases [To be added]
Before thinking too hard about all the features and the class design, I sat down and created some uses cases, asking myself the following question:
"As a user/patient, I would like the app to ...". 

### Features (subject to changes)

* Add selected weather data from an API (API to be determined)
* Export to Excel / CSV / PDF 
* Provide users with options to extend some properties such as types of pain, accompanying symptons etc.

NOTE: These are the starting features.

The class design is based on a paper version of a migran log issued by "Westdeutsches Kopfschmerzentrum (German Headache Centre)" based in Essen, Germany. The class design does not adhere exactly to the original, however, most of the properties are incorporated into the class design. I first used a graphics tool (YeD Graph Editor) to draw the overall class design. My initial version looked like this:

[Add image]

I then realised that I could some apply some inheritance to reduce the amount of typing and smoothen the overall design. I also realised, that I had not previously accounted for the weather data.

[Add image]

As you can see from the inital design, I left out any users for the start, which I did on purpose. The overall goal was to create a version that I could use on my own. I consider users, authentication and logins as features that would only be added at later stage, once the main parts of the application were working as intended.

### Update

In attempt to clean my existing code, I realized that I lost track of the complexity involved in such an endeavour. I messed my one and only controller. That is why I decided to change my approach in favour of the _walking skeleton_ approach. The focus now is to create a running application with the desired features. Changes from an architectual point of view (e.g. repository pattern) are to be added at a later stage. 

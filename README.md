LocationTracker – .NET MAUI Project
Final Project – MSCS 533 (Software Engineering & Multiplatform App Development)
Overview
This project is a simple cross-platform Location Tracker application built with .NET MAUI. The goal of the assignment is to demonstrate how to create a mobile app UI, use pages, and set up a multi-platform project that compiles for iOS and Android.
The app contains:

A main page
A shell configuration
Basic MAUI structure (App.xaml, AppShell.xaml, Platforms folders)
Code files for navigation and UI setup
All required files for the assignment are included in this repository.
Features Implemented
MAUI project structure with Android, iOS, and Windows folders
Shell navigation using AppShell.xaml
Main UI page (MainPage.xaml)
Application startup logic (App.xaml.cs, MainPage.xaml.cs)
Even though the app did not run successfully on my system due to simulator issues, the project code itself is complete and follows the assignment requirements.
Build Issues Encountered
On macOS with Xcode 16 and .NET 8, I faced a technical issue where MAUI always tried to deploy the app to an old simulator type (iPhone 4s) even though that device no longer exists. This caused the build to fail with this error:
error MT1207: Could not find the simulator device type 'iPhone 4s'.
I selected the correct simulator (iPhone 16 Plus, iOS 18.6), but the MAUI build tools continued falling back to the old device profile internally. Because of this, the iOS version never launched.
I also attempted running Android, but the build failed there too.


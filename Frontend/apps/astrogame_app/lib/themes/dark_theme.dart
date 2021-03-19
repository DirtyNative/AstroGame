import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';

ThemeData darkTheme = new ThemeData(
    // Used for smooth swiping
    pageTransitionsTheme: PageTransitionsTheme(
      builders: {
        TargetPlatform.android: CupertinoPageTransitionsBuilder(),
        TargetPlatform.iOS: CupertinoPageTransitionsBuilder(),
      },
    ),
    primaryColor: Colors.white,
    accentColor: Colors.white,
    cardColor: AstroGameColors.lightGrey,
    backgroundColor: AstroGameColors.mediumGrey,
    textTheme: new TextTheme(
      // A special header
      headline1: TextStyle(
        fontFamily: 'TTFirsNeue',
        fontSize: 48,
        fontWeight: FontWeight.w700,
        letterSpacing: 0.5,
        color: Colors.white,
      ),
      headline2: TextStyle(
        fontFamily: 'TTFirsNeue',
        fontSize: 16,
        fontWeight: FontWeight.w700,
        color: Colors.white,
      ),
      headline3: TextStyle(
        fontFamily: 'TTFirsNeue',
        fontSize: 16,
        fontWeight: FontWeight.w500,
        color: Colors.white,
      ),
      bodyText1: TextStyle(
        fontFamily: 'TTFirsNeue',
        fontSize: 14,
        fontWeight: FontWeight.w400,
        color: Colors.white,
      ),
      bodyText2: TextStyle(
        fontFamily: 'TTFirsNeue',
        fontSize: 14,
        fontWeight: FontWeight.w400,
        color: Colors.white,
      ),
      button: TextStyle(
          fontFamily: 'TTFirsNeue',
          fontSize: 14,
          fontWeight: FontWeight.w500,
          color: Colors.white,
          letterSpacing: 0.7),
      subtitle1: TextStyle(
        fontFamily: 'TTFirsNeue',
        fontSize: 14,
        fontWeight: FontWeight.w400,
        color: Colors.white,
      ),
    ),

    // Button Themes
    /*buttonTheme: ButtonThemeData(
    buttonColor: PlatypusColors.aqua,
    disabledColor: Colors.red,
    textTheme: ButtonTextTheme.accent,
    shape: new RoundedRectangleBorder(
      borderRadius: BorderRadius.circular(50),
    ),
    minWidth: 168,
  ),*/

    elevatedButtonTheme: ElevatedButtonThemeData(
      style: ButtonStyle(
        shape: MaterialStateProperty.resolveWith<OutlinedBorder>((states) {
          return new RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(50),
          );
        }),
        backgroundColor: MaterialStateProperty.resolveWith<Color>((states) {
          if (states.contains(MaterialState.disabled)) {
            if (states.contains(MaterialState.hovered)) {
              return Colors.white;
            }

            return Colors.white;
          }

          return AstroGameColors.purple;
        }),
        elevation: MaterialStateProperty.all(0),
        minimumSize: MaterialStateProperty.all(
          Size(500, 32),
        ),
      ),
    ),

    // Used by TextFields
    inputDecorationTheme: InputDecorationTheme(
      labelStyle: TextStyle(color: Colors.white),
      contentPadding: EdgeInsets.only(left: 8, right: 8, top: 8, bottom: 8),
      isDense: true,
      enabledBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(25),
        borderSide: BorderSide(
          color: Colors.white10,
        ),
      ),
      focusedBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(8),
        borderSide: BorderSide(
          color: AstroGameColors.purple[400],
        ),
      ),
      hintStyle: TextStyle(
        color: Colors.white54,
      ),
      fillColor: AstroGameColors.lightGrey,
      filled: true,
    ),

    // Bottom navigation bar
    bottomNavigationBarTheme: BottomNavigationBarThemeData(
      backgroundColor: Colors.white,
      selectedItemColor: AstroGameColors.purple,
    ),

    /// The theme for all Icons
    iconTheme: IconThemeData(
      color: Colors.white,
      size: 16,
    ),
    primaryIconTheme: IconThemeData(color: Colors.white));

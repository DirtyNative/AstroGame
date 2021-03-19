import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

ThemeData darkTheme = new ThemeData(
  // Used for smooth swiping
  pageTransitionsTheme: PageTransitionsTheme(
    builders: {
      TargetPlatform.android: CupertinoPageTransitionsBuilder(),
      TargetPlatform.iOS: CupertinoPageTransitionsBuilder(),
    },
  ),
  primaryColor: AstroGameColors.primary,
  accentColor: Colors.white,
  cardColor: AstroGameColors.darkBlue,
  backgroundColor: AstroGameColors.darkBlue,
  textTheme: new TextTheme(
    // A special header
    headline1: GoogleFonts.fjallaOne(
      fontSize: 48,
      fontWeight: FontWeight.w700,
      letterSpacing: 0.5,
      color: Colors.white,
    ),
    headline2: TextStyle(
      fontFamily: 'Roboto',
      fontSize: 16,
      fontWeight: FontWeight.w700,
      color: Colors.white,
    ),
    headline3: GoogleFonts.fjallaOne(
      //fontFamily: 'Roboto',
      fontSize: 16,
      fontWeight: FontWeight.w500,
      color: Colors.white,
    ),
    bodyText1: TextStyle(
      fontFamily: 'Roboto',
      fontSize: 14,
      fontWeight: FontWeight.w400,
      color: AstroGameColors.grey20,
    ),
    bodyText2: TextStyle(
      fontFamily: 'Roboto',
      fontSize: 14,
      fontWeight: FontWeight.w400,
      color: AstroGameColors.grey20,
    ),
    button: TextStyle(
      fontFamily: 'Roboto',
      fontSize: 14,
      fontWeight: FontWeight.w400,
      color: Colors.white,
    ),
    subtitle1: TextStyle(
      fontFamily: 'Roboto',
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

        return AstroGameColors.primary;
      }),
      elevation: MaterialStateProperty.all(0),
      minimumSize: MaterialStateProperty.all(
        Size(167, 32),
      ),
    ),
  ),

  // Used by TextFields
  inputDecorationTheme: InputDecorationTheme(
    labelStyle: TextStyle(color: Colors.white),
    contentPadding: EdgeInsets.only(bottom: 12),
    isDense: true,
    enabledBorder: UnderlineInputBorder(
      borderSide: BorderSide(
        color: Colors.white,
      ),
    ),
    focusedBorder: UnderlineInputBorder(
      borderSide: BorderSide(color: AstroGameColors.primary),
    ),
    hintStyle: TextStyle(
      color: Colors.white,
    ),
  ),
  bottomNavigationBarTheme: BottomNavigationBarThemeData(
    backgroundColor: Colors.white,
    selectedItemColor: AstroGameColors.primary,
  ),

  /// The theme for all Icons
  iconTheme: IconThemeData(
    color: Colors.white,
    size: 16,
  ),
);

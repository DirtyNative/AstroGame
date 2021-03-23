import 'package:astrogame_app/helpers/router.dart';
import 'package:astrogame_app/themes/dark_theme.dart';
import 'package:flutter/material.dart';
import 'package:stacked_services/stacked_services.dart';
import 'package:stacked_themes/stacked_themes.dart';

import 'helpers/route_paths.dart';

class AstroGameApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ThemeBuilder(
      themes: [
        darkTheme,
        darkTheme,
      ],
      builder: (context, regularTheme, darkTheme, themeMode) => MaterialApp(
        title: 'Flutter Demo',
        theme: regularTheme,
        darkTheme: darkTheme,
        themeMode: themeMode,
        navigatorKey: StackedService.navigatorKey,
        onGenerateRoute: generateRoute,
        initialRoute: RoutePaths.LoginRoute,
        //home: StartView(),
      ),
    );
  }
}

import 'dart:io';

//import 'package:bitsdojo_window/bitsdojo_window.dart';
import 'package:flutter/material.dart';
import 'package:responsive_builder/responsive_builder.dart';
import 'package:stacked_themes/stacked_themes.dart';
import 'app.dart';
import 'configurations/service_container.dart';

Future run() async {
  WidgetsFlutterBinding.ensureInitialized();
  configureDependencies();

  await ThemeManager.initialise();

  runApp(AstroGameApp());

  if (Platform.isWindows || Platform.isLinux || Platform.isMacOS) {
    //await DesktopWindow.setMinWindowSize(Size(200, 400));

    /*doWhenWindowReady(() {
      appWindow.minSize = Size(200, 400);
      appWindow.show();
    }); */
  }

  ResponsiveSizingConfig.instance.setCustomBreakpoints(
    ScreenBreakpoints(desktop: 800, tablet: 550, watch: 0),
  );
}

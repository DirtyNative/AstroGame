import 'dart:io';

import 'package:flutter/material.dart';
import 'package:responsive_builder/responsive_builder.dart';
import 'package:stacked_themes/stacked_themes.dart';
import 'app.dart';
import 'configurations/custom_http_overrides.dart';
import 'configurations/service_container.dart';
import 'package:desktop_window/desktop_window.dart';

Future main() async {
  WidgetsFlutterBinding.ensureInitialized();
  configureDependencies();

  HttpOverrides.global = CustomHttpOverrides();

  await ThemeManager.initialise();

  if (Platform.isWindows || Platform.isLinux || Platform.isMacOS) {
    await DesktopWindow.setMinWindowSize(Size(200, 400));
  }

  ResponsiveSizingConfig.instance.setCustomBreakpoints(
    ScreenBreakpoints(desktop: 800, tablet: 550, watch: 0),
  );

  runApp(AstroGameApp());
}

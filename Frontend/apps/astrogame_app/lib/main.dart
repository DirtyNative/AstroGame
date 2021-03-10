import 'dart:io';

import 'package:flutter/material.dart';
import 'package:stacked_themes/stacked_themes.dart';
import 'app.dart';
import 'configurations/custom_http_overrides.dart';
import 'configurations/service_container.dart';

Future main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await configureDependencies();

  HttpOverrides.global = CustomHttpOverrides();

  await ThemeManager.initialise();

  runApp(AstroGameApp());
}

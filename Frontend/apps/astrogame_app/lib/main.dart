import 'package:flutter/material.dart';
import 'package:stacked_themes/stacked_themes.dart';
import 'app.dart';
import 'configurations/service_container.dart';

Future main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await configureDependencies();

  await ThemeManager.initialise();

  runApp(AstroGameApp());
}

import 'dart:io';

import 'configurations/custom_http_overrides.dart';
import 'configurations/runnable_environment.dart';
import 'main.dart';

void main() async {
  // Adjust the HttpClients to accept invalid ssl certs
  // Note: This is only run in Debug
  HttpOverrides.global = CustomHttpOverrides();

  // Set the Environment
  RunableEnvironment.environment = Environments.DEVELOPMENT;

  await run();
}

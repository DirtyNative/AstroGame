import 'configurations/runnable_environment.dart';
import 'main.dart';

void main() async {
  // Set the Environment
  RunableEnvironment.environment = Environments.STAGING;

  await run();
}

import 'package:astrogame_app/configurations/runnable_environment.dart';
import 'package:injectable/injectable.dart';

@singleton
class ServerConnection {
  late String baseAdress;

  ServerConnection() {
    Environments environment = RunableEnvironment.environment;

    // Dev
    if (environment == Environments.DEVELOPMENT) {
      baseAdress = 'https://localhost:7555';
    }

    // Staging
    else if (environment == Environments.STAGING) {
      baseAdress = 'https://localhost:8555';
    }

    // Production
    else {
      baseAdress = 'https://localhost:9555';
    }
  }
}

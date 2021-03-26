enum Environments { DEVELOPMENT, STAGING, PRODUCTION }

class RunableEnvironment {
  static Environments environment;

  static bool isDevelopment() => environment == Environments.DEVELOPMENT;

  static bool isStaging() => environment == Environments.STAGING;

  static bool isProduction() => environment == Environments.PRODUCTION;
}

class ExecuterResult {
  bool success;

  ExecuterResult(this.success);

  ExecuterResult.success() {
    success = true;
  }

  ExecuterResult.error() {
    success = false;
  }
}

class ExecuterResultT1<T1> {
  bool success;
  T1 data;

  ExecuterResultT1(this.success, this.data);

  ExecuterResultT1.error() {
    success = false;
  }

  ExecuterResultT1.success(this.data) {
    success = true;
  }
}

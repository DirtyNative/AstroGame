import 'server_error.dart';

/// Creates a response from the server which contains the data and the exception if present
class ServerResponse {
  ServerError error;

  bool get hasError => error != null;
}

/// Creates a response from the server which contains the exception if present
class ServerResponseT<T> {
  ServerError error;
  T data;

  bool get hasError => error != null;
}

import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:signalr_core/signalr_core.dart';
import 'package:http/http.dart' as http;

import '../server_connection.dart';

abstract class HubBase {
  HubConnection? _connection;
  HttpHeaderProvider _httpHeaderProvider;
  late String url;

  HubBase(
    this._httpHeaderProvider,
    ServerConnection _serverConnection,
    String path,
  ) {
    url = _serverConnection.baseAdress + path;
  }
  Future connectAsync() async {
    final httpClient = _HttpClient(_httpHeaderProvider.getHeaders());

    _connection = HubConnectionBuilder()
        .withUrl(
          url,
          HttpConnectionOptions(
            logging: (level, message) => print(message),
            client: httpClient,
          ),
        )
        .withAutomaticReconnect()
        .build();

    await _connection?.start();

    registerEvents(_connection!);
  }

  void registerEvents(HubConnection connection);
}

class _HttpClient extends http.BaseClient {
  final _httpClient = http.Client();
  final Map<String, String> defaultHeaders;

  _HttpClient(this.defaultHeaders);

  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) {
    request.headers.addAll(defaultHeaders);
    return _httpClient.send(request);
  }
}

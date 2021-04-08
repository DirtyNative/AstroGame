import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:http/http.dart' as http;
import 'package:astrogame_app/communications/server_connection.dart';
import 'package:astrogame_app/communications/hubs/hub_base.dart';
import 'package:injectable/injectable.dart';
import 'package:signalr_core/signalr_core.dart';

@singleton
class BuildingHub extends HubBase {
  ServerConnection _serverConnection;
  HttpHeaderProvider _httpHeaderProvider;

  BuildingHub(
    this._serverConnection,
    this._httpHeaderProvider,
  ) {
    url = _serverConnection.baseAdress + "/hub/building";
  }

  @override
  Future connectAsync() async {
    final httpClient =
        _HttpClient(defaultHeaders: _httpHeaderProvider.getHeaders());

    connection = HubConnectionBuilder()
        .withUrl(
          url,
          HttpConnectionOptions(
            logging: (level, message) => print(message),

            client: httpClient,

            //client: IOClient(
            //    HttpClient()..badCertificateCallback = (x, y, z) => true),
          ),
        )
        .withAutomaticReconnect()
        .build();

    await connection.start();

    connection.on('BuildingConstructionFinished',
        (arguments) => onBuildingConstructionFinished);
  }

  void onBuildingConstructionFinished() {
    print('Construction finished');
  }
}

class _HttpClient extends http.BaseClient {
  final _httpClient = http.Client();
  final Map<String, String> defaultHeaders;

  _HttpClient({@required this.defaultHeaders});

  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) {
    request.headers.addAll(defaultHeaders);
    return _httpClient.send(request);
  }
}

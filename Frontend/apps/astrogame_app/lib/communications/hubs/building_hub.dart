import 'package:astrogame_app/events/server_events/buildings/building_construction_finished_event.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/providers/constructed_buildings_provider.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:http/http.dart' as http;
import 'package:astrogame_app/communications/server_connection.dart';
import 'package:astrogame_app/communications/hubs/hub_base.dart';
import 'package:injectable/injectable.dart';
import 'package:signalr_core/signalr_core.dart';

@singleton
class BuildingHub extends HubBase {
  EventService _eventService;

  ServerConnection _serverConnection;
  HttpHeaderProvider _httpHeaderProvider;
  BuildingChainProvider _buildingChainProvider;
  ConstructedBuildingsProvider _constructedBuildingsProvider;

  BuildingHub(
    this._eventService,
    this._serverConnection,
    this._httpHeaderProvider,
    this._buildingChainProvider,
    this._constructedBuildingsProvider,
  ) : super(_serverConnection.baseAdress + '/hub/building') {}

  @override
  Future connectAsync() async {
    final httpClient = _HttpClient(_httpHeaderProvider.getHeaders());

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

    await connection?.start();

    connection?.on('BuildingConstructionFinished', (args) async {
      //await _buildingChainProvider.updateAsync();

      _buildingChainProvider.removeFromStellarObjectAsync(new Guid(args?[0]));
      await _constructedBuildingsProvider.updateAsync();

      _eventService.fire(new BuildingConstructionFinishedEvent());
    });
  }
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

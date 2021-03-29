import 'package:astrogame_app/communications/apis/species_api.dart';
import 'package:astrogame_app/communications/server_connection.dart';
import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/players/species.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class SpeciesRepository {
  Logger _logger;

  SpeciesApi _speciesApi;

  ServerConnection _serverConnection;

  SpeciesRepository(Dio dio, this._logger, this._serverConnection) {
    _speciesApi = new SpeciesApi(dio);
  }

  Future<ServerResponseT<List<Species>>> getAllAsync() async {
    try {
      _logger.d('Get all species');
      var response = await _speciesApi.getAllAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<ImageProvider>> getImageAsync({
    @required Guid speciesId,
  }) async {
    try {
      _logger.d('Get species image');

      var httpHeaderProvider = ServiceLocator.get<HttpHeaderProvider>();

      return ServerResponseT()
        ..data = NetworkImage(
            _serverConnection.baseAdress + '/api/v1/species/image/$speciesId',
            headers: httpHeaderProvider.getHeaders());
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}

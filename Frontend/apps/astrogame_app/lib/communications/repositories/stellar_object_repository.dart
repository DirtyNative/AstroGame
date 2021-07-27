import 'package:astrogame_app/communications/apis/stellar_object_api.dart';
import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';

import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_connection.dart';
import '../server_error.dart';
import '../server_response.dart';

@injectable
class StellarObjectRepository {
  Logger _logger;

  late StellarObjectApi _stellarObjectApi;

  ServerConnection _serverConnection;

  StellarObjectRepository(Dio dio, this._logger, this._serverConnection) {
    _stellarObjectApi = new StellarObjectApi(dio);
  }

  Future<ServerResponseT<StellarObject>> getAsync(Guid id) async {
    try {
      _logger.d('Get StellarObject');

      var stellarObject = await _stellarObjectApi.getAsync(id);

      return ServerResponseT()..data = stellarObject;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    } catch (error) {
      throw error;
    }
  }

  Future<ServerResponseT<ImageProvider>> getImageAsync(
    Guid stellarObjectId,
  ) async {
    try {
      _logger.d('Get StellarObject image');

      var httpHeaderProvider = ServiceLocator.get<HttpHeaderProvider>();

      return ServerResponseT()
        ..data = NetworkImage(
          _serverConnection.baseAdress +
              '/api/v1/stellar-object/image/$stellarObjectId',
          headers: httpHeaderProvider.getHeaders(),
        );
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}

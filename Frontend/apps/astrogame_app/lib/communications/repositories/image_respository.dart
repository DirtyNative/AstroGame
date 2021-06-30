import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_connection.dart';
import '../server_error.dart';
import '../server_response.dart';

@injectable
class ImageRepository {
  Logger _logger;

  HttpHeaderProvider _httpHeaderProvider;
  ServerConnection _serverConnection;

  ImageRepository(Dio dio, this._logger, this._serverConnection, this._httpHeaderProvider);

  Future<ServerResponseT<ImageProvider>> getImageAsync(
    String address,
  ) async {
    try {
      _logger.d('Get building image');
      return ServerResponseT()..data = NetworkImage(address, headers: _httpHeaderProvider.getHeaders());
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<ImageProvider>> getBuildingImageAsync(String assetName) async {
    var address = _serverConnection.baseAdress + '/api/v1/image/building/$assetName';
    return await getImageAsync(address);
  }

  Future<ServerResponseT<ImageProvider>> getResearchImageAsync(String assetName) async {
    var address = _serverConnection.baseAdress + '/api/v1/image/research/$assetName';
    return await getImageAsync(address);
  }

  Future<ServerResponseT<ImageProvider>> getSpeciesImageAsync(String assetName) async {
    var address = _serverConnection.baseAdress + '/api/v1/image/species/$assetName';
    return await getImageAsync(address);
  }

  Future<ServerResponseT<ImageProvider>> getStellarObjectImageAsync(String assetName) async {
    var address = _serverConnection.baseAdress + '/api/v1/image/stellar-object/$assetName';
    return await getImageAsync(address);
  }
}

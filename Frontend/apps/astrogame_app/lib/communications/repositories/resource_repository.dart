import 'package:astrogame_app/communications/apis/resource_api.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class ResourceRepository {
  Logger _logger;

  ResourceApi _resourceApi;

  ResourceRepository(Dio dio, this._logger) {
    _resourceApi = new ResourceApi(dio);
  }

  Future<ServerResponseT<List<Resource>>> getAllAsync() async {
    try {
      _logger.d('Get all Resources');

      var resources = await _resourceApi.getAllAsync();

      return ServerResponseT()..data = resources;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<Resource>>> getAsync(Guid id) async {
    try {
      _logger.d('Get Resource');

      var resource = await _resourceApi.getAsync(id);

      return ServerResponseT()..data = resource;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}

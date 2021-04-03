import 'package:astrogame_app/communications/apis/stored_resource_api.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class StoredResourceRepository {
  Logger _logger;

  StoredResourceApi _storedResourceApi;

  StoredResourceRepository(Dio dio, this._logger) {
    _storedResourceApi = new StoredResourceApi(dio);
  }

  Future<ServerResponseT<List<StoredResource>>>
      getOnCurrentStellarObjectAsync() async {
    try {
      _logger.d('Get StoredResources on current StellarObject');

      var storedResources =
          await _storedResourceApi.getOnCurrentStellarObjectAsync();

      return ServerResponseT()..data = storedResources;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<StoredResource>>> getOnStellarObjectAsync(
      Guid stellarObjectId) async {
    try {
      _logger.d('Get StoredResources on StellarObject');

      var storedResources =
          await _storedResourceApi.getOnStellarObjectAsync(stellarObjectId);

      return ServerResponseT()..data = storedResources;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}

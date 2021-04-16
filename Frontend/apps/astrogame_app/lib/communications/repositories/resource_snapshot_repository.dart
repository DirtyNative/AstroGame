import 'package:astrogame_app/communications/apis/resource_snapshot_api.dart';
import 'package:astrogame_app/models/resources/resource_snapshot.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class ResourceSnapshotRepository {
  Logger _logger;

  ResourceSnapshotApi _resourceSnapshotApi;

  ResourceSnapshotRepository(Dio dio, this._logger) {
    _resourceSnapshotApi = new ResourceSnapshotApi(dio);
  }

  Future<ServerResponseT<ResourceSnapshot>> getAsync(
      Guid stellarObjectId) async {
    try {
      _logger.d('Get ResourceSnapshot on StellarObject');

      var storedResources =
          await _resourceSnapshotApi.getAsync(stellarObjectId);

      return ServerResponseT()..data = storedResources;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}

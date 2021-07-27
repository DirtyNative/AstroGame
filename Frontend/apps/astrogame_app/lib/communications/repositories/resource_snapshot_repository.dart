import 'package:astrogame_app/communications/apis/resource_snapshot_api.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/resources/resource_snapshot.dart';
import 'package:dio/dio.dart';

import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class ResourceSnapshotRepository {
  Logger _logger;

  late ResourceSnapshotApi _resourceSnapshotApi;

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
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}

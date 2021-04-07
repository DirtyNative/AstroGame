import 'package:astrogame_app/communications/apis/building_chain_api.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class BuildingChainRepository {
  Logger _logger;

  BuildingChainApi _buildingChainApi;

  BuildingChainRepository(
    Dio dio,
    this._logger,
  ) {
    _buildingChainApi = new BuildingChainApi(dio);
  }

  Future<ServerResponseT<BuildingChain>> getByCurrentPlayerAsync() async {
    try {
      _logger.d('Get building chain by current player');
      var response = await _buildingChainApi.getByCurrentPlayerAsync();

      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}

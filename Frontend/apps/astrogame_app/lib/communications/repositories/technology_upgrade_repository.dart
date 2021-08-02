import 'package:astrogame_app/communications/apis/technology_upgrade_api.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:dio/dio.dart';

import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class TechnologyUpgradeRepository {
  Logger _logger;

  late TechnologyUpgradeApi _technologyUpgradeApi;

  TechnologyUpgradeRepository(Dio dio, this._logger) {
    _technologyUpgradeApi = new TechnologyUpgradeApi(dio);
  }

  Future<ServerResponseT<List<TechnologyUpgrade>>> getAllAsync() async {
    try {
      _logger.d('Get all technology upgrades');
      var response = await _technologyUpgradeApi.getAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}

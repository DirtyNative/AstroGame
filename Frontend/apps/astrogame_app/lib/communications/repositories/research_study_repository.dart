import 'package:astrogame_app/communications/apis/research_study_api.dart';
import 'package:astrogame_app/models/researches/research_study.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class ResearchStudyRepository {
  Logger _logger;

  late ResearchStudyApi _researchStudyApi;

  ResearchStudyRepository(
    Dio dio,
    this._logger,
  ) {
    _researchStudyApi = new ResearchStudyApi(dio);
  }

  Future<ServerResponseT<ResearchStudy>> getByCurrentPlayerAsync() async {
    try {
      _logger.d('Get all researches');
      var response = await _researchStudyApi.getByCurrentPlayerAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}

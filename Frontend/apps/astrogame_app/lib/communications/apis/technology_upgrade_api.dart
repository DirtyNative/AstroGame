import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:dio/dio.dart';

import 'package:retrofit/retrofit.dart';

part 'technology_upgrade_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/technology-upgrade')
abstract class TechnologyUpgradeApi {
  factory TechnologyUpgradeApi(Dio dio, {String baseUrl}) =
      _TechnologyUpgradeApi;

  @GET('/')
  Future<List<TechnologyUpgrade>> getAsync();
}

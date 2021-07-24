import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/models/finished_technologies/levelable_player_dependent_finished_technology.dart';
import 'package:astrogame_app/models/finished_technologies/levelable_stellar_object_dependent_finished_technology.dart';
import 'package:astrogame_app/models/finished_technologies/one_time_player_dependent_finished_technology.dart';
import 'package:astrogame_app/models/finished_technologies/one_time_stellar_object_dependent_finished_technology.dart';
import 'package:json_annotation/json_annotation.dart';

class FinishedTechnologyConverter
    implements JsonConverter<FinishedTechnology, Map<String, dynamic>> {
  const FinishedTechnologyConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'LevelablePlayerDependentFinishedTechnology') {
      return LevelablePlayerDependentFinishedTechnology.fromJson(json);
    } else if (type.value ==
        'LevelableStellarObjectDependentFinishedTechnology') {
      return LevelableStellarObjectDependentFinishedTechnology.fromJson(json);
    } else if (type.value == 'OneTimePlayerDependentFinishedTechnology') {
      return OneTimePlayerDependentFinishedTechnology.fromJson(json);
    } else if (type.value ==
        'OneTimeStellarObjectDependentFinishedTechnology') {
      return OneTimeStellarObjectDependentFinishedTechnology.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

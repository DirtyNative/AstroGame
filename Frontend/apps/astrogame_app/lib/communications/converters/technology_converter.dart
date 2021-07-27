import 'package:astrogame_app/models/buildings/fixed_building.dart';
import 'package:astrogame_app/models/buildings/levelable_building.dart';
import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/researches/one_time_research.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:json_annotation/json_annotation.dart';

class TechnologyConverter
    implements JsonConverter<Technology, Map<String, dynamic>> {
  const TechnologyConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    // Buildings
    if (type.value == 'LevelableBuilding') {
      return LevelableBuilding.fromJson(json);
    } else if (type.value == 'FixedBuilding') {
      return FixedBuilding.fromJson(json);
    }

    // Researches
    if (type.value == 'LevelableResearch') {
      return LevelableResearch.fromJson(json);
    } else if (type.value == 'OneTimeResearch') {
      return OneTimeResearch.fromJson(json);
    }

    throw new UnimplementedError('Technology is not yet implemented');
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

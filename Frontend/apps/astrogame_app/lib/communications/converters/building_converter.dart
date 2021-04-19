import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/fixed_building.dart';
import 'package:astrogame_app/models/buildings/levelable_building.dart';
import 'package:json_annotation/json_annotation.dart';

class BuildingConverter implements JsonConverter<Building, Map<String, dynamic>> {
  const BuildingConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    //var type = json['\$type'];
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'LevelableBuilding') {
      return LevelableBuilding.fromJson(json);
    } else if (type.value == 'FixedBuilding') {
      return FixedBuilding.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

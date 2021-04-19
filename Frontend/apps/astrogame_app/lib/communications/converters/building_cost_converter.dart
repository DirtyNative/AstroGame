import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/dynamic_building_cost.dart';
import 'package:astrogame_app/models/buildings/fixed_building_cost.dart';
import 'package:json_annotation/json_annotation.dart';

class BuildingCostConverter implements JsonConverter<BuildingCost, Map<String, dynamic>> {
  const BuildingCostConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    //var type = json['\$type'];
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'DynamicBuildingCost') {
      return DynamicBuildingCost.fromJson(json);
    } else if (type.value == 'FixedBuildingCost') {
      return FixedBuildingCost.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

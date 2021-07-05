import 'package:astrogame_app/models/buildings/dynamic_building_cost.dart';
import 'package:astrogame_app/models/buildings/fixed_building_cost.dart';
import 'package:astrogame_app/models/researches/dynamic_research_cost.dart';
import 'package:astrogame_app/models/researches/one_time_research_cost.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:json_annotation/json_annotation.dart';

class TechnologyCostConverter
    implements JsonConverter<TechnologyCost, Map<String, dynamic>> {
  const TechnologyCostConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'DynamicBuildingCost') {
      return DynamicBuildingCost.fromJson(json);
    } else if (type.value == 'FixedBuildingCost') {
      return FixedBuildingCost.fromJson(json);
    } else if (type.value == 'OneTimeResearchCost') {
      return OneTimeResearchCost.fromJson(json);
    } else if (type.value == 'DynamicResearchCost') {
      return DynamicResearchCost.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

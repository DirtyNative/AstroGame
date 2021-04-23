import 'package:astrogame_app/models/researches/dynamic_research_cost.dart';
import 'package:astrogame_app/models/researches/one_time_research_cost.dart';
import 'package:astrogame_app/models/researches/research_cost.dart';
import 'package:json_annotation/json_annotation.dart';

class ResearchCostConverter implements JsonConverter<ResearchCost, Map<String, dynamic>> {
  const ResearchCostConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    //var type = json['\$type'];
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'LevelableResearch') {
      return DynamicResearchCost.fromJson(json);
    } else if (type.value == 'OneTimeResearch') {
      return OneTimeResearchCost.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

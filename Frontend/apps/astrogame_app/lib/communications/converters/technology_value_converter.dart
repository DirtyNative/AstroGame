import 'package:astrogame_app/models/buildings/building_value.dart';
import 'package:astrogame_app/models/researches/research_value.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:json_annotation/json_annotation.dart';

class TechnologyValueConverter
    implements JsonConverter<TechnologyValue, Map<String, dynamic>> {
  const TechnologyValueConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'ResearchValueResponse') {
      return ResearchValue.fromJson(json);
    } else if (type.value == 'BuildingValueResponse') {
      return BuildingValue.fromJson(json);
    }

    throw new UnimplementedError('Technology Value is not yet implemented');
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

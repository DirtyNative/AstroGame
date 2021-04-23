import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/researches/one_time_research.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:json_annotation/json_annotation.dart';

class ResearchConverter implements JsonConverter<Research, Map<String, dynamic>> {
  const ResearchConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    //var type = json['\$type'];
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'LevelableResearch') {
      return LevelableResearch.fromJson(json);
    } else if (type.value == 'OneTimeResearch') {
      return OneTimeResearch.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}

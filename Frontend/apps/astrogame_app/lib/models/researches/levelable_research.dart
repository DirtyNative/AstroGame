import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/technologies/levelable_technology.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'levelable_research.g.dart';

@GuidConverter()
@JsonSerializable()
class LevelableResearch extends Research with LevelableTechnology {
  LevelableResearch();

  factory LevelableResearch.fromJson(Map<String, dynamic> json) =>
      _$LevelableResearchFromJson(json);
  Map<String, dynamic> toJson() => _$LevelableResearchToJson(this);
}

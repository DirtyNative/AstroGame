import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'levelable_research.g.dart';

@GuidConverter()
@JsonSerializable()
class LevelableResearch extends Research {
  LevelableResearch();

  factory LevelableResearch.fromJson(Map<String, dynamic> json) => _$LevelableResearchFromJson(json);
  Map<String, dynamic> toJson() => _$LevelableResearchToJson(this);
}

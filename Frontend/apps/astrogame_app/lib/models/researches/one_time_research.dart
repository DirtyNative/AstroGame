import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'one_time_research.g.dart';

@GuidConverter()
@JsonSerializable()
class OneTimeResearch extends Research {
  OneTimeResearch();

  factory OneTimeResearch.fromJson(Map<String, dynamic> json) =>
      _$OneTimeResearchFromJson(json);
  Map<String, dynamic> toJson() => _$OneTimeResearchToJson(this);
}

import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'research_study.g.dart';

@GuidConverter()
@JsonSerializable()
class ResearchStudy {
  Guid id;
  Guid researchId;
  Guid playerId;
  DateTime startTime;
  DateTime endTime;

  ResearchStudy();

  factory ResearchStudy.fromJson(Map<String, dynamic> json) => _$ResearchStudyFromJson(json);
  Map<String, dynamic> toJson() => _$ResearchStudyToJson(this);
}

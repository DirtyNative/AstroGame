import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';

import 'package:json_annotation/json_annotation.dart';

part 'research_study.g.dart';

@GuidConverter()
@JsonSerializable()
class ResearchStudy extends TechnologyUpgrade {
  late Guid playerId;

  ResearchStudy();

  factory ResearchStudy.fromJson(Map<String, dynamic> json) =>
      _$ResearchStudyFromJson(json);
  Map<String, dynamic> toJson() => _$ResearchStudyToJson(this);
}

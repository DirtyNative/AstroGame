import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_cost.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'studied_research.g.dart';

@GuidConverter()
@JsonSerializable()
class StudiedResearch extends Research {
  Guid id;
  Guid researchId;
  Guid playerId;

  int level;

  StudiedResearch();

  factory StudiedResearch.fromJson(Map<String, dynamic> json) =>
      _$StudiedResearchFromJson(json);
  Map<String, dynamic> toJson() => _$StudiedResearchToJson(this);
}

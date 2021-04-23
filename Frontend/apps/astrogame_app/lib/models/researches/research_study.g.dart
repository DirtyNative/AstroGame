// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_study.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResearchStudy _$ResearchStudyFromJson(Map<String, dynamic> json) {
  return ResearchStudy()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..researchId = const GuidConverter().fromJson(json['researchId'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..startTime = json['startTime'] == null
        ? null
        : DateTime.parse(json['startTime'] as String)
    ..endTime = json['endTime'] == null
        ? null
        : DateTime.parse(json['endTime'] as String);
}

Map<String, dynamic> _$ResearchStudyToJson(ResearchStudy instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'researchId': const GuidConverter().toJson(instance.researchId),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'startTime': instance.startTime?.toIso8601String(),
      'endTime': instance.endTime?.toIso8601String(),
    };

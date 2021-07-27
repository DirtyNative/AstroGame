// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_study.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResearchStudy _$ResearchStudyFromJson(Map<String, dynamic> json) {
  return ResearchStudy()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..startTime = DateTime.parse(json['startTime'] as String)
    ..endTime = DateTime.parse(json['endTime'] as String)
    ..hangfireJobId = json['hangfireJobId'] as String
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String);
}

Map<String, dynamic> _$ResearchStudyToJson(ResearchStudy instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'startTime': instance.startTime.toIso8601String(),
      'endTime': instance.endTime.toIso8601String(),
      'hangfireJobId': instance.hangfireJobId,
      'playerId': const GuidConverter().toJson(instance.playerId),
    };

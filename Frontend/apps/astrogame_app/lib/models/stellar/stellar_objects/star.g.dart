// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'star.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Star _$StarFromJson(Map<String, dynamic> json) {
  return Star(
    const GuidConverter().fromJson(json['id'] as String),
    json['name'] as String,
    const GuidConverter().fromJson(json['parentSystemId'] as String),
    (json['averageDistanceToCenter'] as num)?.toDouble(),
    (json['rotationSpeed'] as num)?.toDouble(),
    json['averageTemperature'] as int,
    json['assetName'] as String,
    _$enumDecodeNullable(_$StarTypeEnumMap, json['starType']),
    (json['scale'] as num)?.toDouble(),
    (json['axialTilt'] as num)?.toDouble(),
    (json['resources'] as List)
        ?.map((e) => e == null
            ? null
            : StellarObjectResource.fromJson(e as Map<String, dynamic>))
        ?.toList(),
    json['order'] as int,
  );
}

Map<String, dynamic> _$StarToJson(Star instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentSystemId': const GuidConverter().toJson(instance.parentSystemId),
      'averageDistanceToCenter': instance.averageDistanceToCenter,
      'rotationSpeed': instance.rotationSpeed,
      'averageTemperature': instance.averageTemperature,
      'assetName': instance.assetName,
      'starType': _$StarTypeEnumMap[instance.starType],
      'scale': instance.scale,
      'axialTilt': instance.axialTilt,
      'resources': instance.resources,
      'order': instance.order,
    };

T _$enumDecode<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    throw ArgumentError('A value must be provided. Supported values: '
        '${enumValues.values.join(', ')}');
  }

  final value = enumValues.entries
      .singleWhere((e) => e.value == source, orElse: () => null)
      ?.key;

  if (value == null && unknownValue == null) {
    throw ArgumentError('`$source` is not one of the supported values: '
        '${enumValues.values.join(', ')}');
  }
  return value ?? unknownValue;
}

T _$enumDecodeNullable<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    return null;
  }
  return _$enumDecode<T>(enumValues, source, unknownValue: unknownValue);
}

const _$StarTypeEnumMap = {
  StarType.brownDwarf: 0,
  StarType.yellowDwarf: 1,
  StarType.whiteStar: 2,
  StarType.redGiant: 3,
  StarType.blueGiant: 4,
};
